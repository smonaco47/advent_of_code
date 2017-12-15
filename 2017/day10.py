from fileImport import *

input = readLines('day10.txt')
testString = input[0]
actualString = input[1]

def reverseArray(array, position, length):
    start = position
    end = (position + length - 1) % len(array)
    movements = length/2 + 1
    for i in range(1, movements):
        temp = array[start]
        array[start]=array[end]
        array[end]=temp
        start = (start + 1) % len(array)
        end = (end - 1) % len(array)

def executeRound(array, actions, position, skip):
    for action in actions:
        reverseArray(array, position, action)
        position = (position + skip + action)%len(array)
        skip += 1
    return position, skip

def xOrArray(array):
    val = 0
    for item in array:
         val = val ^ item
    return val

def getHash(array):
    hashString = ""
    for i in range(16):
        integer = xOrArray(array[16*i:16*(i+1)])
        hexString = hex(integer).replace('0x', '')
        if len(hexString) < 2: hexString = '0'*(2-len(hexString))+hexString
        hashString += hexString
    return hashString

def getPart2Hash(input):
    actions = [ord(x) for x in input]
    actions += ([17, 31, 73, 47, 23 ])
    position = 0
    skip = 0
    array = range(256)
    for i in range(64):
        (position,skip) = executeRound(array, actions, position, skip)
    return getHash(array)

# Part 1
actions = [int(x) for x in actualString.split(",")]
array = range(256)
executeRound(array, actions, 0, 0)
print "Part 1: ",array[0] * array[1]

# Part 2
print "Part 2: ",getPart2Hash(actualString)
