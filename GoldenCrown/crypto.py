ALPHABET_START = 65
ALPHABET_END = 90

def encrypt(key, msg):
    encryptedMsg = ""
    for letter in msg:
        encryptedMsg = encryptedMsg + str(get_next_letter(key, letter))
    return encryptedMsg


def get_next_letter(length, letter):
    nextChar = ord(letter)+length
    if(nextChar > ALPHABET_END):
        return chr(ALPHABET_START + (nextChar - ALPHABET_END) - 1)
    elif(nextChar < ALPHABET_START):
        return chr(ALPHABET_END - (ALPHABET_START - nextChar) + 1)
    else:
        return chr(nextChar)


def decrypt(key, msg):
    decryptedMsg = ""
    for letter in msg:
        decryptedMsg = decryptedMsg + str(get_next_letter(-key, letter))
    return decryptedMsg
