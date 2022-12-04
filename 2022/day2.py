from utils import read_file 

key = {
    "A": "rock", 
    "X": "rock",
    "B": "paper",
    "Y": "paper",
    "C": "scissors",
    "Z": "scissors"
}

scores = {
    "rock": 1,
    "paper": 2,
    "scissors": 3
}

outcome_scores = {
    "loss": 0,
    "tie": 3,
    "win": 6
}

# Key = opponent, Sub-key = you
matchups = {
    "rock": {
        "paper": "win",
        "scissors": "loss"
    },
    "paper": {
        "scissors": "win",
        "rock": "loss"
    },
    "scissors": {
        "rock": "win",
        "paper": "loss"
    }
}
# paper beats rock, rock beats scissors, scissors beats paper


def calculate_score(you_play: str, opponent_play: str) -> int:
    match_score = 0
    match_score += scores[you_play] 
    if opponent_play == you_play:
        result = "tie"
    else: 
        result = matchups[opponent_play][you_play]

    match_score += outcome_scores[result]
    return match_score

play_order = [_.strip() for _ in read_file('day2.txt')]

total_score = 0
for match in play_order:
    opponent, you = match.split(" ")
    opponent_play = key[opponent]
    you_play = key[you]

    total_score += calculate_score(you_play, opponent_play)

print("Part 1:", total_score)


goal = {
    "X": "loss",
    "Y": "tie",
    "Z": "win"
}

total_score = 0
for match in play_order:
    opponent, you = match.split(" ")
    opponent_play = key[opponent]
    target_goal = goal[you]

    you_play = None
    if target_goal == "tie": 
        you_play = opponent_play
    else:
        possible_plays = matchups[opponent_play]
        for val in possible_plays.keys():
            if possible_plays[val] == target_goal:
                you_play = val
                break


    total_score += calculate_score(you_play, opponent_play)
    print(you_play, opponent_play, target_goal, total_score)

print("Part 2:", total_score)