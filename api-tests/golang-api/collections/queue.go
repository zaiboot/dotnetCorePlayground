package collections

import (
	"fmt"
	"sync"
)

type Queue struct {
	queue []string
	lock  sync.RWMutex
	count int
}

func New() (c *Queue) {
	return &Queue{
		queue: make([]string, 0),
	}
}

func (c *Queue) Enqueue(name string) {
	c.lock.Lock()
	defer c.lock.Unlock()
	c.queue = append(c.queue, name)
	c.count++
}

func (c *Queue) Dequeue() (string, error) {
	if c.count > 0 {
		c.lock.Lock()
		defer c.lock.Unlock()
		item := c.queue[0]
		c.queue = c.queue[1:]
		c.count--
		return item, nil
	}
	return "", fmt.Errorf("pop Error: Queue is empty")
}

func (c *Queue) Size() int {
	return c.count
}

func (c *Queue) Empty() bool {
	return c.count == 0
}

// func main1() {
// 	customQueue := &queue{
// 		queue: make([]string, 0),
// 	}

// 	fmt.Printf("Enqueue: A\n")
// 	customQueue.Enqueue("A")
// 	fmt.Printf("Enqueue: B\n")
// 	customQueue.Enqueue("B")
// 	fmt.Printf("Len: %d\n", customQueue.Size())

// 	for customQueue.Size() > 0 {

// 		fmt.Printf("Front: %s\n", frontVal)
// 		fmt.Printf("Dequeue: %s\n", frontVal)
// 		customQueue.Dequeue()
// 	}
// 	fmt.Printf("Len: %d\n", customQueue.Size())
// }
