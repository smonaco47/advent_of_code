from fileImport import *
import sys

def parseInput(input):
    action = input[:1]
    data = input[1:].split('/')
    return action, data

def doAction(action, data, array):
    if action == 's':
        array = spinArray(array, int(data[0]))
    if action =='x':
        swapIndices(array, int(data[0]), int(data[1]))
    if action == 'p':
        index1 = int(array.index(data[0]))
        index2 = int(array.index(data[1]))
        swapIndices(array, index1, index2)
    return array

def spinArray(array, numberToSpin):
    return array[len(array)-numberToSpin:]+array[:len(array)-numberToSpin]

def swapIndices(array, index1, index2):
    temp = array[index1]
    array[index1]=array[index2]
    array[index2]= temp

def arrayToString(array):
    string = ''
    for char in array:
        string += char
    return string

def dance(inputList, array):
    for input in inputList:
        (action, data) = parseInput(input)
        array = doAction(action, data, array)
    return array

def getMapping(startArray, finishArry):
    output = [0]*len(startArray)
    for i in range(len(startArray)):
        output[i] = int(finishArry.index(startArray[i]))
    return output

def simulateRound(array, mappings):
    output = [0]*len(startArray)
    for i in range(len(mappings)):
        output[mappings[i]] = array[i]
    return output


inputList = importFile("day16.txt").split(',')
array = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p']
startArray = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p']
endList = dance(inputList, array)
print "Part 1: ",arrayToString(endList)

mapping =  getMapping(startArray, endList)
array = endList
i = 1
# while i < 1000000000:
#     if i %1000000 ==0:
#         print i
#         sys.stdout.flush()
#     i += 1
#     array = simulateRound(array, mapping)
print mapping
print "Part 2: ", arrayToString(array)