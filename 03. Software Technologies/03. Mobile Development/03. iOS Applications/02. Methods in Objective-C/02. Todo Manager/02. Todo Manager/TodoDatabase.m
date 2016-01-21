//
//  TodoDatabase.m
//  02. Todo Manager
//
//  Created by Dimitar Dzhurenov on 1/21/16.
//  Copyright © 2016 Dimitar Dzhurenov. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "TodoDatabase.h"

@implementation TodoDatabase

- (id) init {
    self = [super init];
    if (self) {
        self.todos = [[NSMutableArray alloc] init];
    }
    return self;
}

+ (TodoDatabase *) createStorage {
    TodoDatabase *storage = [[TodoDatabase alloc] init];
    storage.todos = [[NSMutableArray alloc] init];
    return storage;
}

- (void) addTodo: (Todo *) todo {
    [self.todos addObject: todo];
    NSLog(@"\nTODO added: %@", todo);
}

- (void) finishTodo: (Todo *) todo {
    if([self.todos containsObject: todo]){
        [self.todos removeObject:todo];
        [self.todos addObject: todo];
        
    }else{
        NSLog(@"\nTODO not found: %@", todo);
    }
}

- (NSMutableArray *) getAllTodos {
    return self.todos;
}

- (NSMutableArray *) getActiveTodos {
    NSMutableArray *result = [[NSMutableArray alloc] init];
    for (Todo *t in self.todos) {
        
        if (!t.hasExpired && !t.isDone) {
            [result addObject: t];
        }
    }
    
    return result;
}

@end
