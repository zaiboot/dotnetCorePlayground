// main.go
package main

import (
	"zaiboot/golang/infrastructure"
)

func main() {
	logger := infrastructure.InitLog()
	infrastructure.HandleRequests(logger)
}
