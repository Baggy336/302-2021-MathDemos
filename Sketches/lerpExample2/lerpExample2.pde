//Creating our own LERP function!

void setup() {
  size(500, 500);
}

void draw() {
  background(128);

  float p = millis() / 2000.0;
  float size = lerpy(50, 300, p);

  fill(p * 255);
  ellipse(width/2, height/2, size, size);
}



//lerp functions with overloading.

float lerpy(float min, float max, float p){
  
  return lerpy(min, max, p, true);
}

// range = max - min
// range * percent is distance from min
// distance from min + min is the lerp function.

float lerpy(float min, float max, float p, boolean allowExtrapolation) {

  if (allowExtrapolation == false) {

    // Clamping values to get rid of extrapolation
    if (p < 0) p = 0;
    if (p > 1) p = 1;
  }

  float range = max - min;
  float offset = range * p;

  return min + offset;
}
