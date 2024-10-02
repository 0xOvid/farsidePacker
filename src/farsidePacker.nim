import nimcrypto
import base64
import streams
import strutils
import random
import os

var banner* = """
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⠤⠔⠒⣢⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⢀⡠⠤⠤⠤⠮⣅⡀⠀⡎⠀⠀⠀⠀⠀⠀⠀
⠀⠀⢀⠔⠊⠁⠀⠀⠀⠀⠀⠀⠈⠑⢧⡀⠀⠀⠀⠀⠀⠀
⠀⠰⠁⠀⡄⠀⠀⢀⠀⠈⠑⠒⠖⣲⠄⠙⢦⠀⠀⠀⠀⠀
⠀⡇⣠⠔⠁⠀⡀⣈⣐⠒⣒⣊⠉⠀⠀⠀⠈⢳⠀⠀⠀⠀
⢠⠫⢊⡠⠔⠊⠣⡀⠈⠢⣀⠀⠉⠒⢄⠀⠀⠈⣇⠀⠀⠀   farsidePacker - by 0x0vid
⠘⠕⠁⠀⠀⠀⠀⠈⠁⠒⠊⠁⠀⠀⠀⠱⡄⠀⢹⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢱⠀⢸⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⠾⠂⠛⠦⣄⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⠃⣀⡤⢤⣀⡘⡆
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠏⠀⠀⠀⠀⠙⡟
"""
# Global variables
# General AES variables
# https://gist.github.com/byt3bl33d3r/57fe809946b897110e3f5a8eb4a44fd2
# https://github.com/icyguider/Nimcrypt2/blob/main/nimcrypt.nim
var ectx: CTR[aes256]
var key: array[aes256.sizeKey, byte]
var iv: array[aes256.sizeBlock, byte] 
# randomize
discard randomBytes(addr iv[0], 16)

proc rndStr*(): string =
  for _ in .. 20:
    add(result, char(rand(int('A') .. int('z'))))

var envkey: string = rndStr()


proc toByteSeq*(str: string): seq[byte] {.inline.} =
    ## Converts a string to the corresponding byte sequence.
    @(str.toOpenArrayByte(0, str.high))

proc toString(bytes: openarray[byte]): string =
    result = newString(bytes.len)
    copyMem(result[0].addr, bytes[0].unsafeAddr, bytes.len)


proc embedPayload*(infile: string, stub: string): string =
    echo "[+] Reading file: ", inFile

    let blob = readFile(inFile)
    # encrypt
    echo "[+] Encrypting file"
    var data: seq[byte] = toByteSeq(blob)
    var plaintext = newSeq[byte](len(data))
    var enctext = newSeq[byte](len(data))
    # We do not need to pad data, `CTR` mode works byte by byte.
    copyMem(addr plaintext[0], addr data[0], len(data))
    echo "\t[+] Expanding key"
    # Expand key to 32 bytes using SHA256 as the KDF
    var expandedkey = sha256.digest(envkey)
    copyMem(addr key[0], addr expandedkey.data[0], len(expandedkey.data))
    echo "\t[+] Encrypting"
    ectx.init(key, iv)
    ectx.encrypt(plaintext, enctext)
    ectx.clear()
    echo "\t[+] Encoding"
    let encoded = encode(enctext)
    echo "[+] Embedding Payload"
    var outStub = replace(stub, "@@EncryptedPayload@@", encoded)
    echo "[+] Adding encryption material"

    var encMaterial = """
var ectx: CTR[aes256]
var key: array[aes256.sizeKey, byte]
var iv: array[aes256.sizeBlock, byte] = @@iv@@
var envkey: string = "@@key@@"
    """
    outStub = replace(outStub, "#@@AesVariables@@", encMaterial)
    outStub = replace(outStub, "@@iv@@", $iv)
    outStub = replace(outStub, "@@key@@", envkey)
    return outStub

import std/os
proc main() =
    var inFile = paramStr(1)
    var inStub = paramStr(2)
    var outFile = paramStr(3)

    echo "[+] Opening and reading stub"
    try:
        let stub = readFile(inStub)
        var outStub = embedPayload(infile, stub)
        writeFile(outFile, outStub)
        echo "[+] Done! Enjoy"
    except:
        echo "[ERROR] Error opening file"

main()