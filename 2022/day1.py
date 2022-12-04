from utils import read_file 
import numpy as np

file_data = read_file('day1.txt')

sums = []
running_sum = 0
for item in file_data:
    item = item.strip()
    if not item:
        sums.append(running_sum)
        running_sum = 0
    else:
        running_sum += int(item)
if running_sum:
    sums.append(running_sum)
    

np_arr = np.array(sums)

print("Part 1 Max:", np_arr.max())

np_arr.sort()
top_three = np_arr[-3:]
print("Part 1 Max:", top_three.sum())
