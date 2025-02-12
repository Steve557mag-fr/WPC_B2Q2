#include <Arduino_JSON.h>

#define A 11    // A : bouton A (digital  ; bool)
#define B 12    // b : bouton B (digital  ; bool)
#define C 13    // c : bouton C (digidal  ; bool)
#define D 1     // d : slide (analog   ; int)
#define M 0     // m : sound sensor (analog)


void setup() {
  // put your setup code here, to run once:
  pinMode(A, INPUT);
  pinMode(B, INPUT);
  pinMode(C, INPUT);
  
  Serial.begin(9600);

}

void loop() {

  JSONVar data = JSONVar();
  data["A"] = digitalRead(A);
  data["B"] = digitalRead(B);
  data["C"] = digitalRead(C);
  data["D"] = analogRead(D);
  data["M"] = analogRead(M);
  Serial.println(data);

  delay(1000/20);

}
