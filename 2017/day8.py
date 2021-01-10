from fileImport import *
from utility import *

def conditionIsTrue(instuction, registers):
    operator = instruction[5]
    first = 0
    if instruction[4] in registers:
        first = registers[instruction[4]]
    second = int(instruction[6])
    if operator == '>':
        return first > second
    if operator == '>=':
        return first >= second
    if operator == '<':
        return first < second
    if operator == '<=':
        return first <= second
    if operator == '==':
        return first == second
    if operator == '!=':
        return first != second
    return True

data = readLines("day8.txt")
registers = {}
totalMax = 0

for line in data:
    instruction = [x.strip() for x in line.split(' ')]

    if conditionIsTrue(instruction, registers):
        if instruction[0] not in registers:
            registers[instruction[0]] = 0
        if instruction[1] == 'inc' :
            registers[instruction[0]] += int(instruction[2])
        else:
            registers[instruction[0]] -= int(instruction[2])
    maxRegister = max(registers.values())
    if totalMax < maxRegister:
        totalMax = maxRegister


print max(registers.values())
print totalMax