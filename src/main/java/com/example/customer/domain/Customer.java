package com.example.customer.domain;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import java.util.List;

@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
@Entity
public class Customer {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    private String name;
    private String email;

    @ElementCollection
    @CollectionTable(name = "customer_preferences", joinColumns = @JoinColumn(name = "customer_id"))
    @Column(name = "preference")
    private List<String> preferences;
}
