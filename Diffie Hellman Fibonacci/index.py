#import basic stuff
from random import randint
import binascii
def fib(): #defining the fibonacci generating function
	a, b = 0, 1
	while True:
		yield a
		a, b = b, a + b 

def encrypt(text, fiblist): #defining the encryption function with the text to encrypt and array of fibonacci numbers to that point
	binary = bin(int(binascii.hexlify(text), 16))[2:] #convert text to binary
	b = int(binary) #convert that to integer
	print 'To Binary: '+binary #print it to a user so we know it's done right
	n = int(fiblist[len(fiblist)-2])*int(fiblist[len(fiblist)-1]) #generate encryption key by multiplying consecutive fibonacci sequenced numbers
	encrypted = n*b #encryption is complete when binary is multiplied by encryption key
	print '\nEncrypted: '+str(encrypted) #Print to validate with user
	decrypt(encrypted,n) #call the decryption function
def decrypt(text, n):
	decrypted = int(text)/n #divide by the key to get the original binary
	print '\nBack to binary: '+str(decrypted) #print to validate with original binary so we know it's right
	end = [] #define an arbitrary array that will later be joined back
	for a in range(0, len(str(decrypted))): #basically get the original binary back
		end.append(str(decrypted)[a])
	print binascii.unhexlify('%x' % int('0b'+''.join(end), 2)) #print the decrypted text from the binary
	
#actual code
n = randint(5, 10) #define the nth term to which the series will go
fiblist = [] #define the array for the fibonacci series
for index, fibonacci_number in enumerate(fib()): #basically populate the fibonacci array with the previously defined function up to the nth term
     print('{i:3}: {f:3}'.format(i=index, f=fibonacci_number))
     fiblist.append(fibonacci_number)
     if index == n:
         break
text = raw_input("Text to encrypt: ") #get the text to encrypt from the user
encrypt(text, fiblist) #encrypt it
