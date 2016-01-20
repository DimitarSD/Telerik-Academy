//
//  Calculator.h
//  01.Calculator
//
//  Created by Dimitar Dzhurenov on 1/20/16.
//  Copyright © 2016 Dimitar Dzhurenov. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface Calculator: NSObject

@property (strong, nonatomic) NSDecimalNumber *finalResult;

- (Calculator *) initSelf;
- (float) add: (float) value;
- (float) divide: (float) value;
- (float) subtract: (float) value;
- (float) multiply: (float) value;

@end