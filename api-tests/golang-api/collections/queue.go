package collections

import (
	"fmt"
	"sync"
)

// TODO: Make it use interface, to avoid access the underlying collection
type Queue[T any] struct {
	queue []T
	lock  sync.RWMutex
	count int
}

func NewQueue[T any]() (c *Queue[T]) {
	return &Queue[T]{
		queue: make([]T, 0),
	}
}

func (c *Queue[T]) Enqueue(name T) {
	c.lock.Lock()
	defer c.lock.Unlock()
	c.queue = append(c.queue, name)
	c.count++
}

func (c *Queue[T]) Dequeue() (T, error) {
	var item T
	var err error = nil
	if c.count > 0 {
		c.lock.Lock()
		defer c.lock.Unlock()
		item = c.queue[0]
		c.queue = c.queue[1:]
		c.count--
	}
	err = fmt.Errorf("pop Error: Queue is empty")
	return item, err
}

func (c *Queue[_]) Size() int {
	return c.count
}

func (c *Queue[_]) Empty() bool {
	return c.count == 0
}
