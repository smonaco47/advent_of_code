import numpy as np

data = np.fromfile('day1.txt', sep='\n')
print 'Part 1', np.sum(data)

frequency = set()
sum = 0
not_found = True
while not_found:
    for item in np.nditer(data):
        sum += item
        if sum in frequency:
            print 'Part 2', sum
            not_found = False
            break
        else:
            frequency.add(sum)


