use crate::solutions::utils;
use regex::Regex;

pub fn day_1(part_num: &str, file_path: &str) {
    let input = utils::read_to_string(file_path);
    let mut result = 0;
    match part_num {
        "1" => result = run_day_1_part_1(input.as_str()), //56108
        "2" => result = run_day_1_part_2(input.as_str()), //55652
        _ => println!("Unknown part number"),
    }
    println!("{result}");
}

pub fn run_day_1_part_1(input: &str) -> u32 {
    return _day_1(input);
}

pub fn run_day_1_part_2(input: &str) -> u32 {
    // TODO I probably didn't need to reverse the str here
    let mut reversed_str: String = input.chars().rev().into_iter().collect();
    let option_list: [&str; 9] = [
        "eno", "owt", "eerht", "ruof", "evif", "xis", "neves", "thgie", "enin",
    ];
    for idx in 0..reversed_str.len() {
        let substring = &reversed_str[idx..];
        for num in 0..option_list.len() {
            if substring.starts_with(option_list[num]) {
                let mut concat_str: String = "".to_string();
                concat_str.push_str(&reversed_str[..idx]);
                concat_str.push_str(&(num + 1).to_string().as_str());
                concat_str.push_str(&reversed_str[idx + 1..]);
                reversed_str = concat_str;
                break;
            }
        }
    }

    let forward_string: String = reversed_str.chars().rev().into_iter().collect();
    return _day_1(&forward_string);
}

fn _day_1(input: &str) -> u32 {
    let mut count: u32 = 0;
    let mut first: Option<u32> = None;
    let mut last: u32 = 0;
    let re = Regex::new(r"(?<digit>(\d|\n))").unwrap();

    for cap in re.captures_iter(input) {
        let value = convert_to_int(&cap["digit"]);
        if value.is_none() {
            count += (first.unwrap_or(0) * 10) + last;
            first = None;
            last = 0;
        } else {
            if first.is_none() {
                first = value;
            }
            last = value.unwrap();
        }
    }
    count += (first.unwrap_or(0) * 10) + last;

    return count;
}

fn convert_to_int(str_number: &str) -> Option<u32> {
    if str_number == "\n" {
        return None;
    }
    return Some(str_number.parse::<u32>().unwrap());
}

#[cfg(test)]
mod tests {
    #[test]
    fn test_single_value() {
        let test_input = "1b2c";
        let result = crate::solutions::day_1::run_day_1_part_1(test_input);
        assert_eq!(result, 12);
    }

    #[test]
    fn test_multiple_digits() {
        let test_input = "12b3";
        let result = crate::solutions::day_1::run_day_1_part_1(test_input);
        assert_eq!(result, 13);
    }

    #[test]
    fn test_just_digits() {
        let test_input = "12";
        let result = crate::solutions::day_1::run_day_1_part_1(test_input);
        assert_eq!(result, 12);
    }

    #[test]
    fn test_no_digits() {
        let test_input = "abc";
        let result = crate::solutions::day_1::run_day_1_part_1(test_input);
        assert_eq!(result, 0);
    }

    #[test]
    fn test_one_digit() {
        let test_input = "a1";
        let result = crate::solutions::day_1::run_day_1_part_1(test_input);
        assert_eq!(result, 11);
    }

    #[test]
    fn test_simple_example_part_1() {
        let test_input = "1abc2\npqr3stu8vwx\na1b2c3d4e5f\ntreb7uchet";
        let result = crate::solutions::day_1::run_day_1_part_1(test_input);
        assert_eq!(result, 142);
    }

    #[test]
    fn test_word() {
        let test_input = "one2bthree";
        let result = crate::solutions::day_1::run_day_1_part_2(test_input);
        assert_eq!(result, 13);
    }

    #[test]
    fn test_overlapping_words() {
        let test_input = "7fiveonedzbmblrtqfoneightkc";
        let result = crate::solutions::day_1::run_day_1_part_2(test_input);
        assert_eq!(result, 78);
    }

    #[test]
    fn test_simple_example_part_2() {
        let test_input = "two1nine\neightwothree\nabcone2threexyz\nxtwone3four\n4nineeightseven2\n7fiveonedzbmblrtqfoneightkc\nzoneight234\n7pqrstsixteen";
        let result = crate::solutions::day_1::run_day_1_part_2(test_input);
        assert_eq!(result, 281 + 78);
    }
}
