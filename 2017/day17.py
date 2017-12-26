
puzzleInput = 363
values = [0]
index = 0
iterator = 1
for i in range(2017):
    index = (index + puzzleInput + 1) % len(values)
    if not index == 0:
        values.insert(index, iterator)
    else: 
        values.append(iterator)
        index = len(values)-1
    iterator += 1
print values[values.index(2017)+1]

