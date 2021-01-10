import numpy as np

data = np.genfromtxt('day6.txt', delimiter=', ')
max_0 = int(np.max(data[:, 0]))+1
max_1 = int(np.max(data[:, 1]))+1

matrix = np.zeros((max_0, max_1))
distance = np.zeros((max_0, max_1)) + 1000
close = 0
for i in range(max_0):
    for j in range(max_1):
        distance_sum = 0
        for index in range(len(data)):
            x = data[index][0]
            y = data[index][1]
            new_dist = abs(x - i) + abs(y - j)
            distance_sum += new_dist
            if new_dist < distance[i][j]:
                distance[i][j] = new_dist
                matrix[i][j] = index
            elif new_dist == distance[i][j]:
                matrix[i][j] = -1
        if distance_sum <= 10000:
            close += 1

combined = np.concatenate((np.unique(matrix[0, :]), np.unique(matrix[-1, :]), np.unique(matrix[:,0]), np.unique(matrix[:,-1])))
infinite = np.unique(combined.flatten())
for val in infinite:
    matrix[matrix == val] = -1

item, count = np.unique(matrix, return_counts=True)
print 'Part 1', sorted(count, reverse=True)[1]
print 'Part 2', close
