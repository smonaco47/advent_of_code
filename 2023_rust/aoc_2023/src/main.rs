use std::env;
mod solutions;

fn main() {
    let args: Vec<String> = env::args().collect();

    let day = &args[1];
    match day.as_ref(){
        "day1" => crate::solutions::day_1::day_1(&args[2], &args[3]),
        "day2" => crate::solutions::day_2::day_2(&args[2], &args[3]),
        "day3" => crate::solutions::day_3::day_3(&args[2], &args[3]),
        "day4" => crate::solutions::day_4::day_4(&args[2], &args[3]),
        _=>println!("Unknown day: {day}"), 
    }
}
