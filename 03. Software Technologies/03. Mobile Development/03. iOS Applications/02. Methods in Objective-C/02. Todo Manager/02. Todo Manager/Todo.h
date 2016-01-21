//
//  Todo.h
//  02. Todo Manager
//
//  Created by Dimitar Dzhurenov on 1/21/16.
//  Copyright © 2016 Dimitar Dzhurenov. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface Todo : NSObject

@property (strong, nonatomic) NSString *content;
@property (strong, nonatomic) NSDate *date;
@property (nonatomic) bool isDone;

+ (Todo *) createToDoWithContent: (NSString *) content
               andExpirationDate: (NSDate *) date;

- (BOOL) hasExpired;
- (void) finishTodo;
- (NSString *) description;

@end
