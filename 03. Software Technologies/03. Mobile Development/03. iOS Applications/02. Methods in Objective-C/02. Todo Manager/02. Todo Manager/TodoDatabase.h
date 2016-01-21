//
//  TodoDatabase.h
//  02. Todo Manager
//
//  Created by Dimitar Dzhurenov on 1/21/16.
//  Copyright © 2016 Dimitar Dzhurenov. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Todo.h"

@interface TodoDatabase : NSObject

@property (nonatomic, strong) NSMutableArray *todos;

+(TodoDatabase *) createStorage;

-(void) addTodo: (Todo *) todo;
-(void) finishTodo: (Todo *) todo;
-(NSMutableArray *) getAllTodos;
-(NSMutableArray *) getActiveTodos;
@end
