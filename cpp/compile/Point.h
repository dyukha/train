#ifndef _POINT_H_
#define _POINT_H_

#include "IPoint.h"

template<typename T>
class Point : IPoint<T> {
public:  
  Point();
  Point(T x, T y);
  Point(const Point&) = default;
  Point(Point&&) = default;
  Point& operator=(const Point&) = default;
private:
  T x, y;
};

#endif