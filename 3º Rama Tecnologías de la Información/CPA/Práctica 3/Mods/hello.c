#include <stdio.h>
#include <mpi.h>

int main (int argc, char *argv[]){
    int id, procs;

    MPI_Init(&argc, &argv);

    MPI_Comm_size(MPI_COMM_WORLD,&procs);
    MPI_Comm_rank(MPI_COMM_WORLD,&id);
    
    printf("Hello world from %d of %d procs\n",id,procs);
    
    MPI_Finalize();
    return 0;
}