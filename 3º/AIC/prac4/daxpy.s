        # z = a*x + y
        # vector size: 60 elements
        # vector x
	.data
x:      .double 0,1,2,3,4,5,6,7,8,9
        .double 10,11,12,13,14,15,16,17,18,19
        .double 20,21,22,23,24,25,26,27,28,29
        .double 30,31,32,33,34,35,36,37,38,39
        .double 40,41,42,43,44,45,46,47,48,49
        .double 50,51,52,53,54,55,56,57,58,59

	# vector y
y:      .double 100,100,100,100,100,100,100,100,100,100
        .double 100,100,100,100,100,100,100,100,100,100
        .double 100,100,100,100,100,100,100,100,100,100
        .double 100,100,100,100,100,100,100,100,100,100
        .double 100,100,100,100,100,100,100,100,100,100
        .double 100,100,100,100,100,100,100,100,100,100

        # vector z
	# 60 elements are 480 bytes
z:      .space 480

        # scalar a
a:      .double 1

        # code
        .text

start:	
        addi t1,gp,y     # t1 points to y
        addi t2,gp,z     # t2 points to z
        addi t3,gp,x     # t3 points to x
        fld f0,a(gp)     # f0 holds a
        addi t4,t1,480   # 60 elements are 480 bytes
loop:
        fld f1,0(t1)     #cargar y
        fld f3,0(t3)     #cargar x
        fmul.d f2,f3,f0  #multiplicar x*a y guardarlo en f2
        fadd.d f4,f3,f1  #sumar 'y' con el resultado de f2 y guardarlo en f4
        fsd f4, 0(t2)    #guarda el valor de f2 en el vector z
        addi t1,t1,8     #desplaza para coger el siguiente dato
        addi t3,t3,8
        sub t5,t4,t1     #resta el valor de t1 al espacio libre, para contar cuanto queda con t4
        addi t2,t2,8     #mueve tambien el vector z para asignar el valor en la siguiente casilla
        bnez t5,loop     #compara si está ya en el final
        ori a7,zero,10         # end
        ecall

        


