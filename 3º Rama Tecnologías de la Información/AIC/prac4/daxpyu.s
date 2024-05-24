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
        fld f3,8(t1)     #cargar y + 8
        fld f5,16(t1)    #cargar y +16
        fld f7,24(t1)    #cargar y +24

        fld f2,0(t3)     #cargar x
        fld f4,8(t3)     #cargar x +8
        fld f6,16(t3)    #cargar x +16
        fld f8,24(t3)    #cargar x +24

        fmul.d f9,f2,f0  #multiplicar x*a y guardarlo en f9
        fmul.d f11,f4,f0  #multiplicar (x+8)*a y guardarlo en f11
        fmul.d f13,f6,f0  #multiplicar (x+16)*a y guardarlo en f13
        fmul.d f15,f8,f0  #multiplicar (x+24)*a y guardarlo en f15

        fadd.d f10,f9,f1  #sumar 'y' con el resultado de f9 y guardarlo en f10
        fadd.d f12,f11,f3  #sumar 'y + 8' con el resultado de f11 y guardarlo en f12
        fadd.d f14,f13,f5  #sumar 'y+16' con el resultado de f13 y guardarlo en f14
        fadd.d f16,f15,f7  #sumar 'y+24' con el resultado de f15 y guardarlo en f16

        fsd f10, 0(t2)    #guarda el valor de f2 en el vector z
        fsd f12, 8(t2)    #guarda el valor de f2 en el vector z
        fsd f14, 16(t2)    #guarda el valor de f2 en el vector z
        fsd f16, 24(t2)    #guarda el valor de f2 en el vector z

        addi t1,t1,32     #desplaza para coger el siguiente dato despues de los 24 ya cogidos(y)
        addi t3,t3,32     #desplaza para coger el siguiente dato despues de los 24 ya cogidos(x)
        sub t5,t4,t1     #resta el valor de t1 al espacio libre, para contar cuanto queda con t4
        addi t2,t2,32     #mueve tambien el vector z para asignar el valor en la siguiente casilla despues de los 24 ya cogidos
        bnez t5,loop     #compara si está ya en el final
        ori a7,zero,10         # end
        ecall

        


