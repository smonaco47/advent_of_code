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

# Part 1
actions = [int(x) for x in actualString.split(",")]
array = range(256)
executeRound(array, actions, 0, 0)
print "Part 1: ",array[0] * array[1]

# Part 2
actions = [ord(x) for x in actualString]
actions += ([17, 31, 73, 47, 23 ])
position = 0
skip = 0
array = range(256)
for i in range(64):
    (position,skip) = executeRound(array, actions, position, skip)

for i in range(16):
    print hex(xOrArray(array[16*i:16*(i+1)]))

print xOrArray([2,3,4])

