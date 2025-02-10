
#include <Arduino_JSON.h>

#define A 48    // A : bouton A (digital  ; bool)
#define B 50    // b : bouton B (digital  ; bool)
#define C 52    // c : bouton C (digidal  ; bool)
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
  data["A"] = digitalRead(A) == HIGH;
  data["B"] = digitalRead(B) == HIGH;
  data["C"] = digitalRead(C) == HIGH;
  data["D"] = analogRead(D);
  Serial.println(data);


}
