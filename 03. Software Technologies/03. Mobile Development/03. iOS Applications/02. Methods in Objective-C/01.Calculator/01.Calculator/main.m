//
//  main.m
//  01.Calculator
//
//  Created by Dimitar Dzhurenov on 1/20/16.
//  Copyright © 2016 Dimitar Dzhurenov. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Calculator.h"

int main(int argc, const char * argv[]) {
    @autoreleasepool {
        Calculator *calculator = [[Calculator alloc] init];
        float number = 123.234;
        
        NSLog(@"%@", calculator.finalResult);
        NSLog(@"Adding %f", number);
        
        float result  = [calculator add: number];
        NSLog(@"Result: %f", result);
        
        number = 11;
        NSLog(@"Subtracting %f", number);
        
        result  = [calculator subtract: number];
        NSLog(@"Result: %f", result);
    }
    return 0;
}
