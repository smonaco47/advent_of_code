str_input = ">>><<><>><<<>><>>><<<>>><<<><<<>><>><<>>"

from utils import read_file 
str_input = read_file('day17.txt')[0].strip()

# ####

# .#.
# ###
# .#.

# ..#
# ..#
# ###

# #
# #
# #
# #

# ##
# ##

# Y relative to 3 more than than highest item in tower
piece_starting_locations = {
    0: [(2, 0), (3, 0), (4, 0), (5, 0)],
    1: [(2, 1), (3, 1), (4, 1), (3, 2), (3, 0)],
    2: [(2, 0), (3, 0), (4, 0), (4, 1), (4, 2)],
    3: [(2, 0), (2, 1), (2, 2), (2, 3)],
    4: [(2, 1), (3, 1), (2, 0), (3, 0)],
}
    
occupied_locations = set()
width = 7

def is_valid(piece_locations: list) -> bool:
    for loc in piece_locations:
        if loc[0] < 0 or loc[0] >= width:
            return False
        if loc[1] < 0:
            return False
    return len(occupied_locations.intersection(set(piece_locations))) == 0


def settle_piece(piece_locations: list, prev_max: int):
    new_max = prev_max
    for loc in piece_locations:
        occupied_locations.add(loc)
        new_max = max(loc[1], new_max)
    return new_max

def get_start_position(piece_locations: list, prev_max: int):
    return [(loc[0], loc[1] + prev_max + 4) for loc in piece_locations]

def move_down(piece_locations: list):
    return [(loc[0], loc[1] - 1) for loc in piece_locations]

def move_right(piece_locations: list):
    return [(loc[0] + 1, loc[1]) for loc in piece_locations]

def move_left(piece_locations: list):
    return [(loc[0] - 1, loc[1] ) for loc in piece_locations]

# occupied_locations.add((2,0))
# print(is_valid(piece_starting_locations[0]))
# print(settle_piece(piece_starting_locations[1], 0))
# print(occupied_locations)

prev_max = -1
# foo = piece_starting_locations[0]
# print(foo)
# print(move_right(foo))
# print(move_left(foo))
# print(move_down(foo))
# print(get_start_position(foo, prev_max))

first_5 = []
last_5 = []
minimized = []

i = 0
for piece_index in range(1000000000000):
    piece_loc = get_start_position(piece_starting_locations[piece_index % 5], prev_max)
    # print("start", piece_loc)

    if piece_index % 100000 == 0:
        print(piece_index, prev_max)

    while True:
        if str_input[i % len(str_input)] == "<":
            new_loc = move_left(piece_loc)
            if is_valid(new_loc):
                piece_loc = new_loc
        
        elif str_input[i % len(str_input)] == ">":
            new_loc = move_right(piece_loc)
            if is_valid(new_loc):
                piece_loc = new_loc

        i += 1

        new_loc = move_down(piece_loc)
        if not is_valid(new_loc):
            prev_max = settle_piece(piece_loc, prev_max)
            # print("end", piece_loc, prev_max)
            break
        else:
            piece_loc = new_loc
    
    if piece_index < 5:
        first_5.append(piece_loc)
    else:
        if len(last_5) > 5:
            last_5 = last_5[1:]
        last_5.append(piece_loc)
        min_for_group = last_5[0][0][1]
        for piece in last_5:
            for loc in piece:
                min_for_group = min(min_for_group, loc[1])
        minimized = []
        for piece in last_5:
            minimized.append(get_start_position(piece, -1 * min_for_group - 4))

    # print(first_5)
    # print(last_5, minimized)

    if first_5 == minimized:
        print("hooray!", piece_index, prev_max)
        break

print("Part 1", prev_max + 1)