from fileImport import *

def move(direction, input, x, y, values):
    if (input[x][y]not in {'|','-','+'}):
        values.append(input[x][y])
    if input[x][y] == '+':
        direction = findNewDirection(direction, input, x, y)
    if direction == 3:
        x += 1
    if direction == 1:
        x -= 1
    if direction == 2:
        y += 1
    if direction == 4:
        y -= 1
    return x,y,direction

def findNewDirection(direction, input, x, y):
    if direction == 1 or direction == 3:
        if input[x][y-1] != ' ':
            return 4
        if input[x][y+1] != ' ':
            return 2
    if direction == 2 or direction == 4:
        if input[x-1][y] != ' ':
            return 1
        if input[x+1][y] != ' ':
            return 3

input = readLines("day19.txt")
x = 0
start = input[x].index('|')
y =start
direction = 3
values = []

print input[x][y]
count = 0
while input[x][y] != ' ':
    (x,y, direction) = move(direction, input, x, y, values)
    count += 1

print values, count
