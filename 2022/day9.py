from utils import read_file 

motions = [
    "R 4",
    "U 4",
    "L 3",
    "D 1",
    "R 4",
    "D 1",
    "L 5",
    "R 2",
]

motions = read_file('day9.txt')

def update_t_pos(new_h, old_t):
    diff_x = new_h[0] - old_t[0]
    diff_y = new_h[1] - old_t[1]
    
    new_pos = old_t.copy()

    if abs(diff_x) <=1 and abs(diff_y) <= 1:
        return new_pos

    # print(diff_x, diff_y)

    # Same x
    if diff_x == 0 and abs(diff_y) == 2:
        new_pos[1] = old_t[1] + diff_y // 2

    # Same y
    elif diff_y == 0 and abs(diff_x) == 2:
        new_pos[0] = old_t[0] + diff_x // 2
        
    else:
        new_pos[0] = old_t[0] + 1 * (diff_x//abs(diff_x))
        new_pos[1] = old_t[1] + 1 * (diff_y//abs(diff_y))

    return new_pos


h_pos = [0, 0]
t_pos = [0, 0]

location_set = set()
for move in motions:
    dir, n = move.strip().split(" ")

    for _ in range(int(n)):
        if dir == "U":
            h_pos[0] += 1
        if dir == "L":
            h_pos[1] -= 1
        if dir == "D":
            h_pos[0] -= 1
        if dir == "R":
            h_pos[1] += 1
        t_pos = update_t_pos(h_pos, t_pos)
        location_set.add(f"{t_pos[0]}_{t_pos[1]}")
    print(move, h_pos, t_pos)

print("Part 1", len(location_set))



location_set_part_2 = set()

locations = [[0, 0] for _ in range(10)]
for move in motions:
    dir, n = move.strip().split(" ")

    for _ in range(int(n)):
        if dir == "U":
            locations[0][0] += 1
        if dir == "L":
            locations[0][1] -= 1
        if dir == "D":
            locations[0][0] -= 1
        if dir == "R":
            locations[0][1] += 1

        for i in range(1, len(locations)):
            locations[i] = update_t_pos(locations[i-1], locations[i])
        location_set_part_2.add(f"{locations[-1][0]}_{locations[-1][1]}")

    # print(move, locations)
    
print("Part 2", len(location_set_part_2))