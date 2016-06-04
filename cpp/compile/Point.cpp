#include "Point.h"

template <typename T>
Point<T>::Point(T x, T y) : x(x), y(y) { };

template <typename T>
IPoint<T> * operator+(const IPoint<T>& lhs, const IPoint<T>& rhs) {
  return new Point<T>(lhs.X() + rhs.X(), lhs.Y() + rhs.Y());
}

template <typename T>
IPoint<T>* operator-(const IPoint<T>& lhs, const IPoint<T>& rhs) {
  return new Point<T>(lhs.X() - rhs.X(), lhs.Y() - rhs.Y());
}

template <typename T>
IPoint<T>* IPoint<T>::Create(T x, T y) {
  return new Point<T>(x, y);
};
