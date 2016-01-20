//
//  Calculator.m
//  01.Calculator
//
//  Created by Dimitar Dzhurenov on 1/20/16.
//  Copyright © 2016 Dimitar Dzhurenov. All rights reserved.
//

#import "Calculator.h"

@implementation Calculator

- (Calculator *) initSelf{
    Calculator *calculator = [[Calculator alloc] init];
    calculator.finalResult = [[NSDecimalNumber alloc] initWithDouble: 0];
    
    return calculator;
}

- (float) add: (float) number{
    self.finalResult = [self.finalResult decimalNumberByAdding:[[NSDecimalNumber alloc] initWithFloat: number]];
    return [self.finalResult floatValue];
}

- (float) divide: (float) divider{
    self.finalResult = [self.finalResult decimalNumberByDividingBy:[[NSDecimalNumber alloc] initWithFloat: divider]];
    return [self.finalResult floatValue];
}

- (float) subtract:(float) number{
    self.finalResult = [self.finalResult decimalNumberBySubtracting:[[NSDecimalNumber alloc] initWithFloat: number]];
    return [self.finalResult floatValue];
}

- (float) multiply: (float) number{
    self.finalResult = [self.finalResult decimalNumberByMultiplyingBy:[[NSDecimalNumber alloc] initWithFloat: number]];
    return [self.finalResult floatValue];
}
@end