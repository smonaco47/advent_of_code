example_monkeys = {
    'm0': {
        "items": [79, 98],
        "operation": lambda o: o * 19,
        "test": 23,
        "true": lambda: 'm2',
        "false": lambda: 'm3',
        "inspected": 0
    },
    'm1': {
        "items": [54, 65, 75, 74],
        "operation": lambda o: o + 6,
        "test": 19,
        "true": lambda: 'm2',
        "false": lambda: 'm0',
        "inspected": 0
    },
    'm2': {
        "items": [79, 60, 97],
        "operation": lambda o: o * o,
        "test": 13,
        "true": lambda: 'm1',
        "false": lambda: 'm3',
        "inspected": 0
    },
    'm3': {
        "items": [74],
        "operation": lambda o: o + 3,
        "test": 17,
        "true": lambda: 'm0',
        "false": lambda: 'm1',
        "inspected": 0
    }
}

monkeys = {
    'm0': {
        "items": [66, 79],
        "operation": lambda o: o * 11,
        "test": 7,
        "true": lambda: 'm6',
        "false": lambda: 'm7',
        "inspected": 0
    },
    'm1': {
        "items": [84, 94, 94, 81, 98, 75],
        "operation": lambda o: o * 17,
        "test": 13,
        "true": lambda: 'm5',
        "false": lambda: 'm2',
        "inspected": 0
    },
    'm2': {
        "items": [85, 79, 59, 64, 79, 95, 67],
        "operation": lambda o: o + 8,
        "test": 5,
        "true": lambda: 'm4',
        "false": lambda: 'm5',
        "inspected": 0
    },
    'm3': {
        "items": [70],
        "operation": lambda o: o + 3,
        "test":  19,
        "true": lambda: 'm6',
        "false": lambda: 'm0',
        "inspected": 0
    },
    'm4': {
        "items": [57, 69, 78, 78],
        "operation": lambda o: o + 4,
        "test": 2 ,
        "true": lambda: 'm0',
        "false": lambda: 'm3',
        "inspected": 0
    },
    'm5': {
        "items": [65, 92, 60, 74, 72],
        "operation": lambda o: o + 7,
        "test": 11,
        "true": lambda: 'm3',
        "false": lambda: 'm4',
        "inspected": 0
    },
    'm6': {
        "items": [77, 91, 91],
        "operation": lambda o: o * o,
        "test":  17 ,
        "true": lambda: 'm1',
        "false": lambda: 'm7',
        "inspected": 0
    },
    'm7': {
        "items": [76, 58, 57, 55, 67, 77, 54, 99],
        "operation": lambda o: o + 6,
        "test": 3 ,
        "true": lambda: 'm2',
        "false": lambda: 'm1',
        "inspected": 0
    },
}

# monkeys = example_monkeys

gcd = 3
for monkey in monkeys.keys():
    gcd *= monkeys[monkey]["test"]

for _ in range(10000):
    for monkey in monkeys.keys():
        original_items = monkeys[monkey]["items"]
        monkeys[monkey]["items"] = []
        for item in original_items:
            item_worry_level = item
            item_worry_level = monkeys[monkey]["operation"](item_worry_level)
            # item_worry_level = item_worry_level // 3 # Part 1
            item_worry_level = item_worry_level % gcd
            if item_worry_level % monkeys[monkey]["test"] == 0:
                new_monkey = monkeys[monkey]["true"]()
            else:
                new_monkey = monkeys[monkey]["false"]()
            
            monkeys[new_monkey]["items"].append(item_worry_level)
            monkeys[monkey]["inspected"] += 1

for monkey in monkeys.keys():
    # print(monkey,  monkeys[monkey]["items"], monkeys[monkey]["inspected"])
    print(monkey,  monkeys[monkey]["inspected"])