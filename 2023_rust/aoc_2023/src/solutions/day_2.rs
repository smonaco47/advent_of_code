use std::cmp::max;

use crate::solutions::utils;
use regex::Regex;

#[derive(Debug, PartialEq)]
pub struct BlockCounts {
    red: u32,
    green: u32,
    blue: u32,
    game_id: Option<u32>,
}

pub fn day_2(part_num: &str, file_path: &str) {
    let input = utils::read_to_string(file_path);
    let mut result = 0;
    match part_num {
        "1" => {
            result = run_day_2_part_1(
                input.as_str(),
                BlockCounts {
                    red: 12,
                    green: 13,
                    blue: 14,
                    game_id: None,
                },
            )
        }
        "2" => result = run_day_2_part_2(input.as_str()),
        _ => println!("Unknown part number"),
    }
    println!("{result}");
}

fn run_day_2_part_1(input: &str, puzzle_input: BlockCounts) -> u32 {
    let mut sum = 0;
    let split_input = input.split('\n').map(|s| s.to_string());
    for game_input in split_input {
        let game_min = get_minimum_valid(game_input.as_ref());
        if game_min.green <= puzzle_input.green
            && game_min.red <= puzzle_input.red
            && game_min.blue <= puzzle_input.blue
        {
            sum += game_min.game_id.unwrap();
        }
    }
    return sum;
}

fn run_day_2_part_2(input: &str) -> u32 {
    let mut sum = 0;
    let split_input = input.split('\n').map(|s| s.to_string());
    for game_input in split_input {
        let game_min = get_minimum_valid(game_input.as_ref());
        sum += game_min.red * game_min.blue * game_min.green;
    }
    return sum;
}

fn get_minimum_valid(game_str: &str) -> BlockCounts {
    // TODO how do I return something like a tuple?
    let re = Regex::new(r"Game (?<game>(\d+)): (?<game_results>(.*))").unwrap();
    let cap = re.captures(game_str).unwrap();
    let game_num: u32 = cap["game"].parse::<u32>().unwrap();
    let game_results: &str = &cap["game_results"];

    let re_results = Regex::new(r"(?<game_result>(\d+ blue|\d+ green|\d+ red))").unwrap();

    let mut counts: BlockCounts = BlockCounts {
        game_id: Some(game_num),
        red: 0,
        blue: 0,
        green: 0,
    };
    for cap in re_results.captures_iter(game_results) {
        let mut split_str = cap["game_result"].split_whitespace().map(|s| s.to_string());
        let count = split_str.next().unwrap().parse::<u32>().unwrap();
        let cube_color = split_str.next().unwrap();

        match cube_color.as_ref() {
            "red" => counts.red = max(counts.red, count),
            "green" => counts.green = max(counts.green, count),
            "blue" => counts.blue = max(counts.blue, count),
            _ => println!("Unknown color {cube_color}"),
        }
    }
    return counts;
}

#[cfg(test)]
mod tests {
    use crate::solutions::day_2::BlockCounts;

    #[test]
    fn test_possible() {
        let test_input = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";
        let result = crate::solutions::day_2::run_day_2_part_1(
            test_input,
            crate::solutions::day_2::BlockCounts {
                red: 12,
                green: 13,
                blue: 14,
                game_id: None,
            },
        );
        assert_eq!(result, 1);
    }

    #[test]
    fn test_impossible() {
        let test_input = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";
        let result = crate::solutions::day_2::run_day_2_part_1(
            test_input,
            crate::solutions::day_2::BlockCounts {
                red: 3,
                green: 13,
                blue: 14,
                game_id: None,
            },
        );
        assert_eq!(result, 0);
    }

    #[test]
    fn test_example() {
        let test_input = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green\nGame 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue\nGame 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red\nGame 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red\nGame 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green";
        let result = crate::solutions::day_2::run_day_2_part_1(
            test_input,
            crate::solutions::day_2::BlockCounts {
                red: 12,
                green: 13,
                blue: 14,
                game_id: None,
            },
        );
        assert_eq!(result, 8);
    }

    #[test]
    fn test_get_minimum_valid() {
        let test_input = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";
        let result = crate::solutions::day_2::get_minimum_valid(test_input);
        assert_eq!(
            result,
            BlockCounts {
                red: 4,
                green: 2,
                blue: 6,
                game_id: Some(1)
            }
        );
    }

    #[test]
    fn test_example_part_2() {
        let test_input = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green\nGame 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue\nGame 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red\nGame 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red\nGame 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green";
        let result = crate::solutions::day_2::run_day_2_part_2(test_input);
        assert_eq!(result, 2286);
    }
}
