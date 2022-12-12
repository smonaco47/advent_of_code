from utils import read_file 


commands = read_file('day10.txt')

register_values = [1]
sprite_pictogram = []

signal_idx = 0
signal_value = 1

for command in commands:
    if signal_idx > 180:
        print(command.strip(), signal_idx, signal_value)

    if command.startswith("noop"):
        register_values.append(signal_value)
        signal_idx += 1
    elif command.startswith("addx"):
        _, add_val = command.strip().split(" ")
        register_values.append(signal_value)
        register_values.append(signal_value)
        signal_idx += 2
        signal_value += int(add_val)

register_values.append(signal_value)

print(signal_idx, len(register_values))

signal_strength_sum = 0
interesting_values = [20, 60, 100, 140, 180, 220]
for value in interesting_values:
    signal_strength = (value * register_values[value])
    print(register_values[value], signal_strength)
    signal_strength_sum += signal_strength


print("Part 1", signal_strength_sum)


print(register_values[1:21])

part_2_diagram = []
for idx, registry_value in enumerate(register_values[1:]):
    distance_from_sprite_center = abs(registry_value-idx % 40)
    print(idx, registry_value, distance_from_sprite_center)
    part_2_diagram.append("#" if distance_from_sprite_center <= 1 else ".")
# part_2_diagram = ["#" if abs(val-1-idx) <= 1 else "." for idx, val in enumerate(register_values[1:])]

for start_index in range(0,240,40):
    print("".join(part_2_diagram[start_index:start_index+40]))