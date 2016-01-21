//
//  main.m
//  02. Todo Manager
//
//  Created by Dimitar Dzhurenov on 1/21/16.
//  Copyright © 2016 Dimitar Dzhurenov. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Todo.h"
#import "TodoDatabase.h"

int main(int argc, const char * argv[]) {
    @autoreleasepool {
        NSLog(@"TODO Database");
        
        TodoDatabase *storage = [[TodoDatabase alloc] init];
        
        Todo *firstTodo = [Todo  createToDoWithContent: @"First TODO"
                              andExpirationDate: [NSDate dateWithString: @"2015-03-24 10:45:32 +0600"]];
        
        
        Todo *secondTodo= [Todo  createToDoWithContent: @"Second TODO"
                              andExpirationDate: [NSDate dateWithString: @"2014-03-24 10:45:32 +0600"]];
        
        [storage addTodo:firstTodo];
        [storage addTodo:secondTodo];
        
        NSMutableArray *active = storage.getActiveTodos;
        NSLog(@"\n Fetching ACTIVE todos, total: %d", (int) active.count);
        
        for (Todo *todo in active) {
            NSLog(@"\n TODO: %@", todo);
        }
    }
    return 0;
}
