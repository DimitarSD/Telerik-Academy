//
//  main.m
//  02. Dynamic Spiral Matrix
//
//  Created by Dimitar Dzhurenov on 1/6/16.
//  Copyright © 2016 Dimitar Dzhurenov. All rights reserved.
//

#import <Foundation/Foundation.h>

void createMatrix(int matrixSize, int matrix[matrixSize][matrixSize], int size, int startValue){
    if(size < 1)
    {
        return;
    }
    
    int row = (matrixSize - size) / 2;
    int col = (matrixSize - size) / 2;
    
    if(size == 1) {
        matrix[row][col] = startValue;
        return;
    }
    
    for(int i = 0; i < size - 1; i++) {
        matrix[row][col++] = startValue++; //RIGHT
    }
    
    for(int i = 0; i < size - 1; i++) {
        matrix[row++][col] = startValue++; //DOWN
    }
    
    for(int i = 0; i < size - 1; i++) {
        matrix[row][col--] = startValue++; //LEFT
    }
    
    for(int i = 0; i < size - 1; i++) {
        matrix[row--][col] = startValue++; //UP
    }
    
    createMatrix(matrixSize, matrix, size - 2, startValue);
}


int main(int argc, const char * argv[]) {
    @autoreleasepool {
        int size;
        printf("Enter matrix size: ");
        scanf("%d", &size);
        
        int matrix[size][size];
        int startValue = 1;
        createMatrix(size, matrix, size, startValue);
        
        for(int row = 0; row < size; row++) {
            for(int col = 0; col < size; col++) {
                printf("%3d ", matrix[row][col]);
            }
            
            printf("\n");
        }
    }
    
    return 0;
}
