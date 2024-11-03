int potPin1 = A0;  // First potentiometer on analog pin A0
int potPin2 = A1;  // Second potentiometer on analog pin A1

void setup() {
  Serial.begin(9600);  // Start serial communication at 9600 baud
}

void loop() {
  int potValue1 = analogRead(potPin1);  // Read value from the first potentiometer
  int potValue2 = analogRead(potPin2);  // Read value from the second potentiometer
  
  // Send both values in one line, separated by a comma
  Serial.print(potValue1);
  Serial.print(",");
  Serial.println(potValue2);
  
  delay(200);  // Short delay to avoid flooding the serial port
}