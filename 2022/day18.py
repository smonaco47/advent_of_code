from utils import read_file 

locations = read_file('day18_example.txt')

locations = [[int(l) for l in loc.strip().split(',')] for loc in locations]
print(locations)

max_x = 0
max_y = 0
max_z = 0

for loc in locations:
    max_x = max(loc[0], max_x)
    max_y = max(loc[1], max_y)
    max_z = max(loc[2], max_z)

max_x = max_x + 2
max_y = max_y + 2
max_z = max_z + 2

print(max_x, max_y, max_z)

loc_grid = [[[' ' for _ in range(max_z)] for _ in range(max_y)] for _ in range(max_x)]

for loc in locations:
    print(loc)
    loc_grid[loc[0]][loc[1]][loc[2]] = 'X'


def check_location(x,y,z,key='X'):
    if x < 0 or y < 0 or z < 0:
        return True
    if x > max_x or y > max_y or z > max_z:
        return True

    return loc_grid[x][y][z] != key

print(loc_grid)


surface_area = 0
for i in range(max_x):
    for j in range(max_y):
        for k in range(max_z):
            if loc_grid[i][j][k] == 'X':
                if check_location(i+1, j, k):
                    surface_area += 1
                
                if check_location(i-1, j, k):
                    surface_area += 1

                if check_location(i, j+1, k):
                    surface_area += 1

                if check_location(i, j-1, k):
                    surface_area += 1

                if check_location(i, j, k+1):
                    surface_area += 1

                if check_location(i, j, k-1):
                    surface_area += 1


print("Part 1", surface_area)
