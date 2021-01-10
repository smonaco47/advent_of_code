import numpy as np
import re

matrix = np.zeros((28, 27))
match = re.compile(' ([\\w]) [\\s\\w]+ ([\\w]) ')

input = open('day7.txt').readlines()

for line in input:
    v = match.search(line)
    precondition = ord(v.group(1)) % 65
    item = ord(v.group(2)) % 65
    matrix[item, -1] = 1
    matrix[precondition, -1] = 1
    matrix[item][precondition] = 1

copy = np.copy(matrix)

while np.sum(matrix[:,-1]) > 0:
    for i in range(28):
        if matrix[i, -1] == 0:
            continue
        if np.sum(matrix[i][:-1]) == 0:
            # print chr(i + 65)
            matrix[i, -1] = 0
            matrix[:, i] = 0
            break


def getNextItems(m):
    rv = []
    for i in range(28):
        if m[i, -1] == 0:
            continue
        if np.sum(m[i][:-1]) == 0:
            rv.append(i)
            m[i, -1] = 0
    return rv


# Part 2
itr = 0
worker = [0, 0,0,0,0]
active_task = [-1, -1, -1, -1, -1]
available = getNextItems(copy)
num = 5
while True:
    for i in range(num):
        if worker[i] == 0 and active_task[i] >= 0:
                copy[:, active_task[i]] = 0

    needs_new = False
    for i in range(num):
        needs_new = needs_new or worker[i] == 0

    if needs_new and len(available) == 0:
        available.extend(getNextItems(copy))

    for i in range(num):
        if worker[i] == 0:
            if len(available) > 0:
                worker[i] = available.pop()
                active_task[i] = worker[i]
                worker[i] += 60
            else:
                active_task[i] = -1
        else:
            worker[i] -= 1

    if sum(active_task) == -5:
        break

    itr += 1
print itr


