// main.go
package main

import (
	"log"
	"net/http"
	"os"
	"zaiboot/golang/collections"

	"github.com/gorilla/mux"
)

var cq *collections.Queue

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
		w.Write([]byte(item))
	}
}

func handleRequests() {
	myRouter := mux.NewRouter()
	myRouter.HandleFunc("/api/Queue", getSingleItem).Methods("GET")
	myRouter.HandleFunc("/api/Queue/{id}", createNewItem).Methods("PUT")
	port := os.Getenv("PORT")
	log.Fatal(http.ListenAndServe(":"+port, myRouter))
}

func main() {
	cq = collections.New()
	handleRequests()
}
