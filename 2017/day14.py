from day10 import getPart2Hash

testStr = 'flqrgnkx'
actualStr = 'amgozmfv'

def getStartString(input, value):
    return input + '-' + str(value)

def getBinaryForHex(input):
    return bin(int(input,16))[2:]

def getUsedSpaces(input):
    binary = getBinaryForHex(input)
    sum = 0
    for bit in binary:
        if bit == '1':
            sum += 1
    return sum

def getTotalUsedSpaces(input, size):
    sum = 0
    for i in range(size):
        string = getStartString(input, i)
        sum += getUsedSpaces(getPart2Hash(string))
    return sum

def buildGrid(input, size):
    array = [['.']*size for item in range(size)]
    for i in range(size):
        string = getStartString(input, i)
        binary = getBinaryForHex(getPart2Hash(string))
        binaryLength = len(binary)
        for j in range(binaryLength):
            if binary[j] == '1':
                array[i][j + (size-binaryLength)] = 'X'
    return array

def printGrid(array):
    for i in range(len(array)):
        print ''.join(array[i])

def printMiniGrid(array):
    for i in range(8):
        print ''.join(array[i][:8])

def markFound(i, j, array):
    if (i >= len(array) or i < 0): return
    if (j >= len(array) or j < 0): return
    if array[i][j] != 'X': return
    array[i][j] = '+'
    markFound(i+1, j, array)
    markFound(i-1, j, array)
    markFound(i, j+1, array)
    markFound(i, j-1, array)

def findRanges(input, size):
    array = buildGrid(input, size)
    ranges = 0
    for i in range(size):
        for j in range(size):
            if array[i][j] == 'X':
                ranges += 1
                markFound(i, j, array)
    printGrid(array)
    return ranges

#print "Part 1: ",getTotalUsedSpaces(actualStr, 128)

print "Part 2: ", findRanges(actualStr, 128)

#array = buildGrid(testStr, 128)
# markFound(2,4,array)
# printGrid(array)

#print printMiniGrid(array)