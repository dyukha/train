#include <iostream>
#include "IPoint.h"

int main() {
  IPoint<double>* point = IPoint<double>::Create(2., 3.);
  int n = 3;
  for (int i = 0; i < n; i++) {
    IPoint<double>* oldPoint = point;
    point = *point + *point;
    delete oldPoint;
  }
  std::cout << point->X() << " " << point->Y() << std::endl;
  delete point;
  return 0;
}