//
//  main.m
//  01. Spiral Matrix
//
//  Created by Dimitar Dzhurenov on 1/6/16.
//  Copyright © 2016 Dimitar Dzhurenov. All rights reserved.
//

#import <Foundation/Foundation.h>

int main(int argc, const char * argv[]) {
    @autoreleasepool {
        NSArray *matrix = @[
                            @[@1, @2, @3, @4],
                            @[@12, @13, @14, @5],
                            @[@11, @16, @15, @6],
                            @[@10, @9, @8, @7]
                           ];
        
        NSMutableString *matrixAsString = [NSMutableString stringWithString: @"\n"];
        
        for (int row = 0; row < [matrix count]; row++)
        {
            for (int col = 0; col < [matrix[row] count]; col++)
            {
                [matrixAsString appendFormat:@"%@ ", matrix[row][col]];
            }
            
            [matrixAsString appendString: @"\n"];
        }
        
        NSLog(@"%@", matrixAsString);
    }
    return 0;
}
