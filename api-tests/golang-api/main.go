// main.go
package main

import (
	"fmt"
	"log"
	"net/http"

	"github.com/gorilla/mux"
)

var cq *Queue

func createNewItem(w http.ResponseWriter, r *http.Request) {
	vars := mux.Vars(r)
	id := vars["id"]
	cq.Enqueue(id)
}

func getSingleItem(w http.ResponseWriter, r *http.Request) {
	item, err := cq.Dequeue()
	if err != nil {
		w.WriteHeader(http.StatusNoContent)
	} else {
		w.WriteHeader(http.StatusOK)
		fmt.Print(w, item)
	}
}

func handleRequests() {
	myRouter := mux.NewRouter()
	myRouter.HandleFunc("/api/Queue", getSingleItem).Methods("GET")
	myRouter.HandleFunc("/api/Queue/{id}", createNewItem).Methods("PUT")
	log.Fatal(http.ListenAndServe(":6020", myRouter))
}

func main() {
	cq = &Queue{
		queue: make([]string, 0),
	}
	handleRequests()
}
