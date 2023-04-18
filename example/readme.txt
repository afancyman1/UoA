In this example, the client sends two messages to the server. 
For the first message, the server replies a string "Hello client".
For the second message, the server sends the contents of a text file to the client. In the second messagem the client includes the name of the text file.

The format of the message sent by the client is as below:
1st byte: command (0 or 1)
If the value of the first byte is 0, the message only has one byte (this is the first message sent by the client).
If the value of the first byte is 1 (this is the second message sent by the client),
2nd to 5th bytes: the value of the length of the bytes holding the value of the file name to be sent to the client
6th byte to the end of the message: the bytes representing the file name

To run this example:
1. start the server
2. run the client