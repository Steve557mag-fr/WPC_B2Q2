
#include <Arduino_JSON.h>

#define A 41    // A : bouton A (digital  ; bool)
#define B 39    // b : bouton B (digital  ; bool)
#define C 37    // c : bouton C (digidal  ; bool)
#define D 0     // d : coulisse (analog   ; int)

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
  Serial.println(data);

  delay(1000/2);

}
