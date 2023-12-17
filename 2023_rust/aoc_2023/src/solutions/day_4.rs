use crate::solutions::utils;
use std::collections::HashSet;

pub fn day_4(part_num: &str, file_path: &str) {
    let inputs = utils::read_to_vec_of_strings(file_path);
    let mut result = 0;
    match part_num {
        "1" => result = run_day_4_part_1(inputs),
        "2" => result = run_day_4_part_2(inputs),
        _ => println!("Unknown part number"),
    }
    println!("{result}");
}

pub fn run_day_4_part_1(input: Vec<String>) -> u32 {
    let mut score: u32 = 0;
    for in_str in input {
        let matching_count = _get_matching_count(&in_str);
        if matching_count > 0 {
            score += 2_u32.pow(matching_count - 1);
        }
    }
    return score;
}

pub fn run_day_4_part_2(input: Vec<String>) -> u32 {
    let mut scorecards: [u32; 1000] = [0; 1000];

    for (idx, in_str) in input.iter().enumerate() {
        scorecards[idx] += 1;  // One point for original card
        let matching_count = _get_matching_count(in_str);
        if matching_count > 0 {
            for scorecard in (idx + 1)..(matching_count as usize + idx + 1) {
                scorecards[scorecard] += scorecards[idx];
            }
            println!("{}, {}", scorecards[idx], matching_count);
        }
        println!("{:?}", &scorecards[0 .. 10])
    }
    return scorecards.iter().sum();
}

fn _get_matching_count(in_str: &String) -> u32 {
    let split_name = in_str.split(':');
    let all_numbers = split_name.map(str::to_string).nth(1).unwrap();
    let parts = all_numbers.split("|");
    let winning_numbers: HashSet<u32> = _convert_to_set_of_numbers(parts.clone().nth(0).unwrap());
    let our_nmbers: HashSet<u32> = _convert_to_set_of_numbers(parts.clone().nth(1).unwrap());
    let matching_count = our_nmbers.intersection(&winning_numbers).count();
    return matching_count as u32;
}

fn _convert_to_set_of_numbers(in_str: &str) -> HashSet<u32> {
    return HashSet::from_iter(
        in_str
            .split(" ")
            .filter(|i| !i.is_empty())
            .map(|i| i.parse::<u32>().unwrap()),
    );
}

#[cfg(test)]
mod tests {
    #[test]
    fn test_part_1_single_row_points() {
        let test_input = vec!["Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53".to_string()];
        let result = crate::solutions::day_4::run_day_4_part_1(test_input);
        assert_eq!(result, 8);
    }

    #[test]
    fn test_part_1_multiple_row_points() {
        let test_input = vec![
            "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53".to_string(),
            "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19".to_string(),
        ];
        let result = crate::solutions::day_4::run_day_4_part_1(test_input);
        assert_eq!(result, 10);
    }

    #[test]
    fn test_part_1_single_no_matches() {
        let test_input = vec!["Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11".to_string()];
        let result = crate::solutions::day_4::run_day_4_part_1(test_input);
        assert_eq!(result, 0);
    }

    #[test]
    fn test_part_2_multiple_row_points() {
        let test_input = vec![
            "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53".to_string(),
            "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19".to_string(),
        ];
        let result = crate::solutions::day_4::run_day_4_part_2(test_input);
        assert_eq!(result, 10);
    }

    #[test]
    fn test_part_2_example() {
        let test_input = vec![
            "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53".to_string(),
            "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19".to_string(),
            "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1".to_string(),
            "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83".to_string(),
            "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36".to_string(),
            "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11".to_string(),
        ];
        let result = crate::solutions::day_4::run_day_4_part_2(test_input);
        assert_eq!(result, 30);
    }
}
