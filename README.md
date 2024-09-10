# CartScript

Unity assembly style sandbox to write in cartesian coordinate system Beta 0.1
maybe it will extend or not
![betaview](https://github.com/meva0xC/Cartesian-coordinate-system/blob/main/Imgs/img_beta.png)

## Documentation of functions

### Vector
```sh
vec (x,y) (x,y) (obj_name)            
```
### Line 
```sh
line (m,x,b)            
```
### Triangle 
```sh
triangle (x,y) (x,y) (x,y) (obj_name)            
```
Rectangle 
```sh
rectangle (x,y) (x,y) (obj_name)            
```
### Circle 
```sh
circle (x,y) (number) (obj_name)            
```
### Sin 
```sh
sin (x,y) (number) (number) (obj_name)            
```
### Cos 
```sh
cos (x,y) (number) (number) (obj_name)          
```
### Tan
```sh
tan (x,y) (number) (number) (obj_name)           
```
### Figure 
```sh
figure (x,y) (number) (number) (obj_name)            
```
### Angle 
```sh
angle (x,y) (x,y) (x,y) (x,y) (obj_name)            
```
### F 
```c#
f (function_equation)            
```
### Add
```sh
add (number0,number1,...numberN,) (register)            
```
### Sub 
```sh
sub (number0,number1,...numberN,) (register)              
```
### Mul 
```sh
mul (number0,number1,...numberN,) (register)                 
```
### Mov 
```sh
mov (register) (register)           
```
### Cmp 
```sh
cmp (number) (register) (register)             
```
### Inc 
```sh
inc (register)          
```
### Dec 
```sh
dec (register)         
```
### Read
```c#
read (path)          
```
### Write
```sh
write (path)          
```
### Delete
```sh
delete (obj_name)          
```
### Point
```sh
point (x,y) (obj_name)          
```
