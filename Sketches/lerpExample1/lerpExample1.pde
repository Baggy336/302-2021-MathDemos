// Interpolation Lab YAY MATH!!

// LERP 2 values (a, b) on a timeline a being 0%, b being 100%
// Ex. a = 50 and b = 100 value at 50% would be 75.
// lerp (min, max, %) and function spits out corresponding value.

void setup(){
  size(500, 500);
  
}



void draw(){
  background(128);
  
  
  float p = mouseX / (float) width;
  float size = lerp(50, 300, p);
  
  fill(p * 255);
  ellipse(width/2, height/2, size, size);
  
}
