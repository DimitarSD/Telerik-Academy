//
//  Todo.m
//  02. Todo Manager
//
//  Created by Dimitar Dzhurenov on 1/21/16.
//  Copyright © 2016 Dimitar Dzhurenov. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Todo.h"

@implementation Todo

- (Todo *) createToDoWithContent:(NSString *)content
               andExperationDate:(NSDate *)date{
    Todo *todo = [[Todo alloc] init];
    
    todo.isDone = NO;
    todo.content = content;
    todo.date = date;
    
    return todo;
}

- (BOOL) hasExpired{
    return [self.date timeIntervalSinceNow] < 0.f;
}

- (void) finishTodo{
    self.isDone = YES;
}

- (NSString *) description{
    return [NSString stringWithFormat:@"Content: %@, Expiration Date: %@, isDone: %s", self.content, self.date, self.isDone ? "YES" : "NO"];
}

@end