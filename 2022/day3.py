from utils import read_file 

rucksack_contents = [_.strip() for _ in read_file('day3.txt')]

# rucksack_contents = [
#     'vJrwpWtwJgWrhcsFMMfFFhFp',
#     'jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL',
#     'PmmdzqPrVvPwwTWBwg',
#     'wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn',
#     'ttgJtRGJQctTZtZT',
#     'CrZsJsPPZsGzwwsLwLmpwMDw'
# ]

uppercase_offset = ord('A') - 27
lowercase_offset = ord('a') - 1

val_sum = 0
for sack in rucksack_contents:
    sack_mid = len(sack) // 2
    sack_1 = sack[:sack_mid]
    sack_2 = sack[sack_mid:]

    assert len(sack_1) + len(sack_2) == len(sack)
    assert len(sack_1) == len(sack_2)

    sack_1 = set(sack_1)
    sack_2 = set(sack_2)

    dup_items = sack_1.intersection(sack_2)
    (dup_item,) = dup_items

    assert len(dup_items) == 1

    ord_representation = ord(dup_item[0])
    if ord_representation > lowercase_offset:
        value = ord_representation - lowercase_offset
    else:
        value = ord_representation - uppercase_offset

    val_sum += value
    print(dup_item, value)

print("Part 1:", val_sum)



val_sum = 0
for group_start_iterator in range(0, len(rucksack_contents), 3):
    sacks = [set(rucksack_contents[group_start_iterator + i]) for i in range(3)]

    common_items = sacks[0].intersection(sacks[1]).intersection(sacks[2])
    (dup_item,) = common_items

    assert len(dup_items) == 1

    ord_representation = ord(dup_item[0])
    if ord_representation > lowercase_offset:
        value = ord_representation - lowercase_offset
    else:
        value = ord_representation - uppercase_offset

    val_sum += value
    print(dup_item, value)

print("Part 2:", val_sum)