from fileImport import *

def parseInput(input):
    action = input[:1]
    data = input[1:].split('/')
    return action, data

def doAction(action, data, array):
    if action == 's':
        array = spinArray(array, int(data[0]))
    if action =='x':
        swapIndices(array, int(data[0]) - 1, int(data[1]) - 1)
    if action == 'p':
        index1 = int(array.index(data[0]))
        index2 = int(array.index(data[1]))
        swapIndices(array, index1 - 1, index2 - 1)
    return array

def spinArray(array, numberToSpin):
    return array[numberToSpin:]+array[:numberToSpin]

def swapIndices(array, index1, index2):
    temp = array[index1]
    array[index1]=array[index2]
    array[index2]= temp

expectedresult = "baedc"

inputList = importFile("day16.txt").split(',')
array = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p']

for input in inputList:
    (action, data) = parseInput(input)
    array = doAction(action, data, array)

string = ''
for char in array:
    string += char
print string
